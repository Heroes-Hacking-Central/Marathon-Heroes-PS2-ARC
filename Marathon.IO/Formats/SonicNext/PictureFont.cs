﻿using System.IO;
using System.Xml.Linq;
using Marathon.IO.Headers;
using Marathon.IO.Helpers;
using Marathon.IO.Exceptions;
using System.Collections.Generic;

namespace Marathon.IO.Formats.SonicNext
{
    public class PictureFont : FileBase
    {
        public class SubImage
        {
            public string Placeholder;
            public ushort X, Y, Width, Height;
        }

        public const string Signature = "FNTP", Extension = ".pft";

        public string Texture;
        public List<SubImage> Entries = new List<SubImage>();

        public override void Load(Stream stream)
        {
            // Header
            BINAReader reader = new BINAReader(stream);
            reader.ReadHeader();

            string sig = reader.ReadSignature(4);
            if (sig != Signature) throw new InvalidSignatureException(Signature, sig);

            uint texturePos = reader.ReadUInt32();
            uint placeholderEntries = reader.ReadUInt32();

            reader.JumpTo(reader.ReadUInt32(), false);
            long position = reader.BaseStream.Position;

            // Texture
            reader.JumpTo(texturePos, false);
            string texture = reader.ReadNullTerminatedString();
            reader.JumpTo(position, true);

            // Placeholders
            for (uint i = 0; i < placeholderEntries; ++i)
            {
                SubImage fontPicture = new SubImage();
                Texture = texture;

                uint placeholderEntry = reader.ReadUInt32();

                fontPicture.X = reader.ReadUInt16();
                fontPicture.Y = reader.ReadUInt16();
                fontPicture.Width = reader.ReadUInt16();
                fontPicture.Height = reader.ReadUInt16();

                position = reader.BaseStream.Position;

                reader.JumpTo(placeholderEntry, false);
                fontPicture.Placeholder = reader.ReadNullTerminatedString();
                reader.JumpTo(position, true);

                Entries.Add(fontPicture);
            }
        }

        public override void Save(Stream stream)
        {
            // Header
            BINAHeaderV1 header = new BINAHeaderV1();
            BINAWriter writer = new BINAWriter(stream, header);
            writer.WriteSignature(Signature);

            // Texture
            writer.AddString("textureName", Texture);

            // Placeholders
            writer.Write((uint)Entries.Count);
            writer.AddOffset("placeholderEntriesPos");
            writer.FillInOffset("placeholderEntriesPos", false);

            for (int i = 0; i < Entries.Count; i++)
            {
                writer.AddString($"placeholderName{i}", Entries[i].Placeholder);
                writer.Write(Entries[i].X);
                writer.Write(Entries[i].Y);
                writer.Write(Entries[i].Width);
                writer.Write(Entries[i].Height);
            }

            writer.FinishWrite(header);
        }

        public void ExportXML(string filePath)
        {
            // Header
            XElement rootElem = new XElement("PFT");

            // Texture
            XElement typeElem = new XElement("Texture");
            XAttribute typeAttr = new XAttribute("File", Texture);
            typeElem.Add(typeAttr);

            // Placeholders
            for (int i = 0; i < Entries.Count; i++)
            {
                XElement pictureElem = new XElement("Picture", Entries[i].Placeholder);
                pictureElem.Add(new XAttribute("X", Entries[i].X));
                pictureElem.Add(new XAttribute("Y", Entries[i].Y));
                pictureElem.Add(new XAttribute("Width", Entries[i].Width));
                pictureElem.Add(new XAttribute("Height", Entries[i].Height));
                typeElem.Add(pictureElem);
            }

            rootElem.Add(typeElem);

            XDocument xml = new XDocument(rootElem);
            xml.Save(filePath);
        }

        public void ImportXML(string filePath)
        {
            XDocument xml = XDocument.Load(filePath);

            // Texture
            foreach (XElement textureElem in xml.Root.Elements("Texture"))
            {
                Texture = textureElem.Attribute("File").Value;

                // Placeholders
                foreach (XElement pictureElem in textureElem.Elements("Picture"))
                {
                    SubImage entry = new SubImage();
                    ushort.TryParse(pictureElem.Attribute("X").Value, out entry.X);
                    ushort.TryParse(pictureElem.Attribute("Y").Value, out entry.Y);
                    ushort.TryParse(pictureElem.Attribute("Width").Value, out entry.Width);
                    ushort.TryParse(pictureElem.Attribute("Height").Value, out entry.Height);
                    entry.Placeholder = pictureElem.Value;
                    Entries.Add(entry);
                }
            }
        }
    }
}