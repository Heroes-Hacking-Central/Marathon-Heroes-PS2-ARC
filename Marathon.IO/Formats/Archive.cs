﻿// Archive.cs is licensed under the MIT License:
/* 
 * MIT License
 *
 * Copyright (c) 2020 HyperBE32
 * Copyright (c) 2018 Radfordhound
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
using System.Collections.Generic;
using Marathon.IO.Helpers;

namespace Marathon.IO.Formats
{
    /// <summary>
    /// <para>File base used for universal archive management.</para>
    /// </summary>
    public class Archive : FileBase
    {
        /// <summary>
        /// Loads all archive data into memory.
        /// </summary>
        public bool StoreInMemory { get; set; } = false;

        public List<ArchiveData> Data = new List<ArchiveData>();

        public Archive(bool storeInMemory = false) => StoreInMemory = storeInMemory;

        public Archive(string file, bool storeInMemory = false)
        {
            StoreInMemory = storeInMemory;

            Load(file);
        }

        public Archive(Archive arc, bool storeInMemory = false)
        {
            StoreInMemory = storeInMemory;

            Data = arc.Data;
        }

        /// <summary>
        /// Disposes the list of data.
        /// </summary>
        public void Dispose()
        {
            // Clear the data list.
            Data.Clear();

            // Collect remaining garbage.
            GC.Collect(GC.GetGeneration(Data), GCCollectionMode.Forced);
        }

        /// <summary>
        /// Reloads the archive.
        /// </summary>
        public virtual Archive Reload()
            => throw new NotImplementedException();

        /// <summary>
        /// Decompresses the archive data.
        /// </summary>
        /// <param name="files">List of entries to decompress.</param>
        /// <param name="includeSubDirectories">Include subdirectories in the returned list.</param>
        public void Decompress(ref List<ArchiveData> files, bool includeSubDirectories = true)
        {
            foreach (ArchiveData data in files)
            {
                if (includeSubDirectories && data is ArchiveDirectory dir)
                {
                    Decompress(ref dir.Data);
                }
                else if (data is ArchiveFile file)
                {
                    file.Data = file.Decompress(Location, file);
                }
            }
        }

        /// <summary>
        /// Recursively gathers all files from the current list.
        /// </summary>
        /// <param name="files">List of entries to gather from.</param>
        /// <param name="includeSubDirectories">Include subdirectories in the returned list.</param>
        public static List<ArchiveFile> GetFiles(List<ArchiveData> files, bool includeSubDirectories = true)
        {
            List<ArchiveFile> list = new List<ArchiveFile>();

            foreach (ArchiveData data in files)
            {
                if (includeSubDirectories && data is ArchiveDirectory dir)
                {
                    list.AddRange(GetFiles(dir.Data));
                }
                else if (data is ArchiveFile file)
                {
                    list.Add(file);
                }
            }

            return list;
        }

        /// <summary>
        /// Recursively gathers all files from the archive.
        /// </summary>
        /// <param name="includeSubDirectories">Include subdirectories in the returned list.</param>
        public List<ArchiveFile> GetFiles(bool includeSubDirectories = true)
            => GetFiles(Data, includeSubDirectories);

        /// <summary>
        /// Recursively gathers all directories from the current list.
        /// </summary>
        /// <param name="directories">List of entries to gather from.</param>
        public static List<ArchiveDirectory> GetDirectories(List<ArchiveData> directories)
        {
            List<ArchiveDirectory> list = new List<ArchiveDirectory>();

            foreach (ArchiveData data in directories)
            {
                if (data is ArchiveDirectory dir)
                {
                    list.AddRange(GetDirectories(dir.Data));
                }
            }

            return list;
        }

        /// <summary>
        /// Extracts all data from the archive.
        /// </summary>
        /// <param name="directory">Directory to extract to.</param>
        public void Extract(string directory)
        {
            Directory.CreateDirectory(directory);

            foreach (var entry in Data)
                entry.Extract(Path.Combine(directory, entry.Name));
        }

        /// <summary>
        /// Add all files from a directory to the archive.
        /// </summary>
        /// <param name="dir">Directory to add from.</param>
        /// <param name="includeSubDirectories">Include subdirectories in the result.</param>
        public void AddDirectory(string directoryPath, bool includeSubDirectories = false)
            => Data.AddRange(GetFilesFromDirectory(directoryPath, includeSubDirectories));

        /// <summary>
        /// Add all files from a directory to the archive.
        /// </summary>
        /// <param name="dir">Directory to add from.</param>
        /// <param name="base">The directory these nodes should be added to.</param>
        /// <param name="includeSubDirectories">Include subdirectories in the result.</param>
        public void AddDirectory(string directoryPath, ArchiveData @base, bool includeSubDirectories = false)
        {
            // Input is a valid ArchiveDirectory.
            if (@base is ArchiveDirectory dir)
                dir.Data.AddRange(GetFilesFromDirectory(directoryPath, includeSubDirectories));

            // Some other type was used.
            else
                throw new NotSupportedException($"Encountered an archive entry of unsupported type ({@base.GetType()})." +
                                                "The input *must* be an ArchiveDirectory.");
        }

        /// <summary>
        /// Enumerate all files from a directory.
        /// </summary>
        /// <param name="directoryPath">Directory to enumerate from.</param>
        /// <param name="includeSubDirectories">Include subdirectories in the result.</param>
        public List<ArchiveData> GetFilesFromDirectory(string directoryPath, bool includeSubDirectories = false)
        {
            ArchiveDirectory dir = new ArchiveDirectory(Path.GetFileName(directoryPath));

            // Add each file in the current sub-directory.
            foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                ArchiveFile file;

                if (StoreInMemory)
                {
                    file = new ArchiveFile(filePath) { Parent = dir };
                }
                else
                {
                    file = new ArchiveFile()
                    {
                        Name = Path.GetFileName(filePath),
                        Parent = dir,
                        Location = filePath,
                        UncompressedSize = (uint)new FileInfo(filePath).Length
                    };
                }

                dir.Data.Add(file);
            }

            // Repeat for each sub directory.
            if (includeSubDirectories)
            {
                foreach (string subDir in Directory.GetDirectories(directoryPath))
                {
                    dir.Data.Add(new ArchiveDirectory(Path.GetFileName(subDir))
                    {
                        Parent = dir,
                        Data = GetFilesFromDirectory(subDir, includeSubDirectories)
                    });
                }
            }

            return dir.Data;
        }

        /// <summary>
        /// Recursively creates directories based on the input string.
        /// </summary>
        /// <param name="dirPath">Directory pattern.</param>
        public ArchiveDirectory CreateDirectories(string dirPath)
        {
            ArchiveDirectory dir = null;

            foreach (string dirName in dirPath.Split('/'))
            {
                List<ArchiveData> data = dir == null ? Data : dir.Data;

                if (data.Exists(t => t.Name == dirName))
                    dir = data.Find(t => t.Name == dirName) as ArchiveDirectory;

                else if (dir == null)
                {
                    var directory = new ArchiveDirectory(dirName);
                    Data.Add(directory);
                    dir = directory;
                }
                else
                {
                    var newDirectory = new ArchiveDirectory(dirName);
                    dir.Data.Add(newDirectory);
                    newDirectory.Parent = dir;
                    dir = newDirectory;
                }
            }

            return dir;
        }
    }

    public abstract class ArchiveData
    {
        /// <summary>
        /// The name of the entry.
        /// </summary>
        public string Name;

        /// <summary>
        /// The parent node containing this entry.
        /// </summary>
        public ArchiveData Parent = null;

        /// <summary>
        /// Determines whether this entry is a directory or not.
        /// </summary>
        public abstract bool IsDirectory { get; }

        /// <summary>
        /// Placeholder for later implementation.
        /// </summary>
        public virtual void Extract(string placeholder, bool decompress = false, string location = "")
            => throw new NotImplementedException();

        /// <summary>
        /// Recursively gets the total count of all subdirectories.
        /// </summary>
        /// <param name="dataEntries">List of entries to query.</param>
        public static int GetTotalCount(List<ArchiveData> dataEntries)
        {
            int totalCount = dataEntries.Count;

            foreach (var dataEntry in dataEntries)
            {
                if (dataEntry is ArchiveDirectory childDirEntry)
                {
                    /* When we call TotalContentsCount, we recurse again
                       for the child directory. */
                    totalCount += childDirEntry.TotalContentsCount;
                }
            }

            return totalCount;
        }

        /// <summary>
        /// Recursively gets the total size of all data entries.
        /// </summary>
        /// <param name="dataEntries">List of entries to query.</param>
        public static uint GetTotalSize(List<ArchiveData> dataEntries)
        {
            uint totalSize = 0;

            foreach (var dataEntry in dataEntries)
            {
                if (dataEntry is ArchiveDirectory childDirEntry)
                {
                    /* When we call TotalContentsSize, we recurse again
                       for the child directory. */
                    totalSize += childDirEntry.TotalContentsSize;
                }
                else if (dataEntry is ArchiveFile fileEntry)
                {
                    totalSize += fileEntry.UncompressedSize;
                }
            }

            return totalSize;
        }
    }

    public class ArchiveFile : ArchiveData
    {
        /// <summary>
        /// The data pertaining to this file.
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// The size of the file (used if Data isn't populated).
        /// </summary>
        public uint Length;

        /// <summary>
        /// The uncompressed size of this file.
        /// </summary>
        public uint UncompressedSize;

        /// <summary>
        /// The offset where the data is stored.
        /// </summary>
        public uint Offset;

        /// <summary>
        /// The physical location of the file - used for Archive Explorer.
        /// </summary>
        public string Location;

        // This should be false, since it's a file, duh.
        public override bool IsDirectory => false;

        public ArchiveFile() { }

        public ArchiveFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The given file could not be found.", filePath);

            Name = new FileInfo(filePath).Name;
            Data = File.ReadAllBytes(filePath);
            UncompressedSize = (uint)Data.Length;
        }

        public ArchiveFile(string name, byte[] data)
        {
            Name = name;
            Data = data;
        }

        /// <summary>
        /// Decompresses the file data using the overridden method.
        /// </summary>
        public virtual byte[] Decompress(string archive, ArchiveFile file)
        {
            // Archive is new.
            if (!File.Exists(archive))
                return file.Data;

            // File is stored in memory or in an archive.
            if (string.IsNullOrEmpty(Location))
            {
                // Check if the lengths are valid.
                if (file.Length != 0 && file.UncompressedSize != 0)
                {
                    // Write feedback to the console output.
                    ConsoleWriter.WriteLine($"Decompressing {file.Name} ({StringHelper.ByteLengthToDecimalString(file.UncompressedSize)})...");

                    using (var fileStream = File.OpenRead(archive))
                        return Decompress(fileStream, file);
                }

                // File is probably already decompressed.
                else
                    return file.Data;
            }

            // File is stored on disk, so read it.
            else if (!string.IsNullOrEmpty(Location) && Data == null)
            {
                return File.ReadAllBytes(Location);
            }

            // File is probably already decompressed.
            else
                return file.Data;
        }

        /// <summary>
        /// Decompresses the file data using the overridden method.
        /// </summary>
        public virtual byte[] Decompress(Stream stream, ArchiveFile file)
            => throw new NotImplementedException();

        /// <summary>
        /// Extracts file data from the archive.
        /// </summary>
        /// <param name="filePath">Location to extract to.</param>
        public override void Extract(string filePath, bool decompress = false, string location = "")
            => File.WriteAllBytes(filePath, Data);
    }

    public class ArchiveDirectory : ArchiveData
    {
        /// <summary>
        /// The subsequent data contained in this directory.
        /// </summary>
        public List<ArchiveData> Data = new List<ArchiveData>();

        /// <summary>
        /// Total amount of entries in this directory (including subdirectories).
        /// </summary>
        public int TotalContentsCount => GetTotalCount(Data);

        /// <summary>
        /// Total size of entries in this directory (including subdirectories).
        /// </summary>
        public uint TotalContentsSize => GetTotalSize(Data);

        /// <summary>
        /// Determines if the current directory is the root of the archive.
        /// </summary>
        public bool IsRoot;

        // Yes, the class called 'ArchiveDirectory' is a directory.
        public override bool IsDirectory => true;

        public ArchiveDirectory() { }
        public ArchiveDirectory(string directoryName) => Name = directoryName;

        /// <summary>
        /// Extracts all data from the current directory.
        /// </summary>
        /// <param name="directory">Directory to extract to.</param>
        public override void Extract(string directory, bool decompress = false, string location = "")
        {
            Directory.CreateDirectory(directory);

            foreach (ArchiveData data in Data)
            {
                if (decompress && data is ArchiveFile file)
                    file.Data = file.Decompress(location, file);

                data.Extract(Path.Combine(directory, data.Name), decompress, location);
            }
        }
    }
}