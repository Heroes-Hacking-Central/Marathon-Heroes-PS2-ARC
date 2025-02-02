﻿// Marathon is licensed under the MIT License:
/* 
 * MIT License
 * 
 * Copyright (c) 2020 HyperBE32
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
using System.Windows.Forms;
using Marathon.Toolkit.Controls;

namespace Marathon.Toolkit.Forms
{
    public partial class FileConverter : MarathonDockContent
    {
        public FileConverter() => InitializeComponent();

        /// <summary>
        /// Changes the cursor if data is present.
        /// </summary>
        private void FileConverter_DragEnter(object sender, DragEventArgs e) => e.Effect = e.AllowedEffect;

        /// <summary>
        /// Gets the file dropped onto the window.
        /// </summary>
        private void FileConverter_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1) ToolAutoSelect(files[0]);
        }

        /// <summary>
        /// Auto-selects the required tool for the dropped file.
        /// </summary>
        private void ToolAutoSelect(string data)
        {
            throw new NotImplementedException(); // TODO
        }
    }
}
