// CompressedU8Archive.cs is licensed under the MIT License:
/* 
 * MIT License
 * 
 * Copyright (c) 2020 Radfordhound
 * Copyright (c) 2020 GerbilSoft
 * Copyright (c) 2020 HyperPolygon64
 * Copyright (c) 2020 Knuxfan24
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.IO;
using Marathon.IO.Exceptions;
using System.Collections.Generic;

namespace Marathon.IO.Formats.Archives
{
    /// <summary>
    /// File base for the Heroes ARC format.
    /// </summary>
    public class HeroesU8 : FileBase
    {
        public abstract class U8DataEntry
        {
            /// <summary>
            /// Name of the file or directory this U8DataEntry represents.
            /// </summary>
            public string Name;

            /// <summary>
            /// Information about the entry - used for convenience with Archive Explorer.
            /// </summary>
            public U8DataEntryZlib Information;

            /// <summary>
            /// Whether this U8DataEntry represents a directory or a file.
            /// </summary>
            public abstract bool IsDirectory { get; }

            public U8DataEntry() { }
            public U8DataEntry(string name)
            {
                Name = name;
            }

            /// <summary>
            /// Recursively computes the total number of DataEntries contained within the given list.
            /// </summary>
            /// <param name="dataEntries">The list of data entries to recurse through.</param>
            /// <returns>The total, recursive number of DataEntries contained within the given list.</returns>
            public static int GetTotalCount(List<U8DataEntry> dataEntries)
            {
                int totalCount = dataEntries.Count;
                foreach (var dataEntry in dataEntries)
                {
                    if (dataEntry is U8DirectoryEntry childDirEntry)
                    {
                        totalCount += childDirEntry.TotalContentsCount;
                    }
                }

                return totalCount;
            }
        }

        public class U8FileEntry : U8DataEntry
        {
            /// <summary>
            /// Decompressed data of the file.
            /// </summary>
            public byte[] Data;

            public override bool IsDirectory => false;

            public U8FileEntry() { }
            public U8FileEntry(string name, byte[] data) : base(name)
            {
                Data = data;
            }
        }

        public class U8DirectoryEntry : U8DataEntry
        {
            /// <summary>
            /// The directories/files inside the directory.
            /// </summary>
            public List<U8DataEntry> Contents = new List<U8DataEntry>();

            /// <summary>
            /// The total, recursive number of DataEntries contained within this directory.
            /// </summary>
            public int TotalContentsCount => GetTotalCount(Contents);

            public override bool IsDirectory => true;

            public U8DirectoryEntry() { }
            public U8DirectoryEntry(string name) : base(name) { }
        }

        public const uint Signature = 0x55AA382D;
        public const string Extension = ".arc";

        public readonly List<U8DataEntry> Entries = new List<U8DataEntry>();

        public enum U8DataEntryType
        {
            File = 0,
            Directory = 1
        }

        public struct U8DataEntryZlib
        {
            /// <summary>
            /// Various properties of this entry.
            /// </summary>
            /// <remarks>
            /// First byte is the U8 data type (0 == File, 1 == Directory).
            /// 
            /// The remaining 24 bits are the offset to this entry's name relative
            /// to the beginning of the string table. Use TypeMask and NameOffsetMask
            /// to get the respective values.
            /// </remarks>
            public uint Flags;

            /// <summary>
            /// Data pertaining to this entry.
            /// </summary>
            /// <remarks>
            /// For files, this is an offset to the file's data.
            /// 
            /// For directories, this is the index of the parent directory.
            /// The root entry just sets this to 0.
            /// </remarks>
            public uint Data;

            /// <summary>
            /// Size of the data this entry contains.
            /// </summary>
            /// <remarks>
            /// For files, this is the compressed size of the file's data.
            /// 
            /// For directories, this is the index of the next entry that
            /// isn't a child of this one. For the root entry and the final directory
            /// entry in the archive, this happens to be the total entry count
            /// for the entire archive.
            /// </remarks>
            public uint Size;

            public const uint TypeMask = 0xFF000000;
            public const uint NameOffsetMask = 0x00FFFFFF;
            public const uint SizeOf = 12;

            public U8DataEntryType Type => (U8DataEntryType)((Flags & TypeMask) >> 24);
            public uint NameOffset => (Flags & NameOffsetMask);

            public U8DataEntryZlib(ExtendedBinaryReader reader)
            {
                Flags = reader.ReadUInt32();
                Data = reader.ReadUInt32();
                Size = reader.ReadUInt32();
            }
        }

        public override void Load(Stream stream)
        {
            // Create ExtendedBinaryReader.
            var reader = new ExtendedBinaryReader(stream, false);

            // Read archive signature.
            uint signature = reader.ReadUInt32();
            if (signature != Signature)
            {
                throw new InvalidSignatureException(
                    Signature.ToString(), signature.ToString());
            }

            // Read the rest of the standard U8 header.
            uint entriesOffset = reader.ReadUInt32(); // Offset to where the table starts.
            uint entriesLength = reader.ReadUInt32(); // Length of the table.
            uint dataOffset = reader.ReadUInt32(); // Offset to where the data starts.

            // Read U8 root entry.
            reader.JumpTo(entriesOffset);
            var u8RootEntry = new U8DataEntryZlib(reader);

            // Compute string table offset.
            uint strTableOffset = (entriesOffset + (u8RootEntry.Size *
                U8DataEntryZlib.SizeOf));

            // Create U8 entries array and copy root entry into it.
            var u8Entries = new U8DataEntryZlib[u8RootEntry.Size];
            u8Entries[0] = u8RootEntry;

            // Read U8 child entries.
            for (uint i = 1; i < u8RootEntry.Size; ++i)
            {
                u8Entries[i] = new U8DataEntryZlib(reader);
            }

            // Recursively parse U8 entries, converting them into DataEntries.
            ParseEntries(0, Entries, true);

            uint ParseEntries(uint u8EntryIndex, List<U8DataEntry> entries, bool isRoot = false)
            {
                ref U8DataEntryZlib u8Entry = ref u8Entries[u8EntryIndex];

                // Read name.
                reader.JumpTo(strTableOffset + u8Entry.NameOffset);
                string name = reader.ReadNullTerminatedString();

                // Recursively parse Directory entries.
                if (u8Entry.Type == U8DataEntryType.Directory)
                {
                    // Create U8DirectoryEntry and add it to entries.
                    var dirEntry = new U8DirectoryEntry(name);
                    entries.Add(dirEntry);

                    // Set entries to dirEntry.Contents.
                    entries = dirEntry.Contents;

                    // Recursively parse the directory's child entries.
                    uint u8ChildIndex = (u8EntryIndex + 1);
                    while (u8ChildIndex < u8Entry.Size)
                    {
                        u8ChildIndex = ParseEntries(u8ChildIndex, entries);
                    }

                    // Return the index of the next entry.
                    return u8Entry.Size;
                }

                // Parse File entries.
                else if (u8Entry.Type == U8DataEntryType.File)
                {
                    // Create U8FileEntry.
                    U8FileEntry fEntry = new U8FileEntry() { Name = name, Information = u8Entry };

                    reader.JumpTo(u8Entry.Data, false);
                    fEntry.Data = reader.ReadBytes((int)u8Entry.Size);

                    // Add it to entries.
                    entries.Add(fEntry);

                    // Return the index of the next entry.
                    return u8EntryIndex + 1;
                }

                // Throw if we encounter an entry of an unknown type
                else throw new NotSupportedException(
                    $"Encountered an U8 entry of unsupported type ({(uint)u8Entry.Type}).");
            }
        }

        public void Replace(string name)
        {

        }

        public void Extract(string path)
        {
            WriteDataRecursive(Directory.CreateDirectory(path).FullName, (U8DirectoryEntry)Entries[0]);

            void WriteDataRecursive(string location, U8DirectoryEntry directory)
            {
                foreach (U8DataEntry dataEntry in directory.Contents)
                {
                    if (dataEntry is U8FileEntry childFile)
                    {
                        Console.WriteLine($"Extracting: {childFile.Name}");
                        File.WriteAllBytes(Path.Combine(location, childFile.Name), childFile.Data);
                    }

                    if (dataEntry is U8DirectoryEntry childDirectory)
                        WriteDataRecursive(Directory.CreateDirectory(Path.Combine(location, childDirectory.Name)).FullName, childDirectory);
                }
            }
        }
    }
}