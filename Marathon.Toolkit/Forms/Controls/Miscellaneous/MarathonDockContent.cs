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
using System.Linq;
using System.ComponentModel;
using WeifenLuo.WinFormsUI.Docking;
using ComponentFactory.Krypton.Ribbon;
using Marathon.Toolkit.Forms;

namespace Marathon.Toolkit.Controls
{
    public partial class MarathonDockContent : DockContent
    {
        /// <summary>
        /// Initialiser for InDesignHelperMode.
        /// </summary>
        private bool _InDesignHelperMode = true;

        /// <summary>
        /// Enables ribbon design mode.
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Enables ribbon design mode.")]
        public bool InDesignHelperMode
        {
            get => _InDesignHelperMode;
            set => KryptonRibbon_MarathonForm.Visible = _InDesignHelperMode = value;
        }

        /// <summary>
        /// Initialiser for UseRibbon.
        /// </summary>
        private bool _UseRibbon = true;

        /// <summary>
        /// Enables the ribbon for this form (results will be merged with the main ribbon).
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Enables the ribbon for this form (results will be merged with the main ribbon).")]
        public bool UseRibbon
        {
            get => _UseRibbon;
            set => KryptonRibbon_MarathonForm.Visible = _UseRibbon = value;
        }

        /// <summary>
        /// The ribbon control for this form.
        /// </summary>
        [Browsable(false), Description("The ribbon control for this form.")]
        public KryptonRibbon Ribbon => KryptonRibbon_MarathonForm;

        /// <summary>
        /// The ribbon on the main window that we'll pass over controls to.
        /// </summary>
        [Browsable(false), Description("The ribbon on the main window that we'll pass over controls to.")]
        public KryptonRibbon InheritanceRibbon { get; set; }

        public MarathonDockContent()
        {
            InitializeComponent();

            // Don't display the ribbon, we'll combine with the main one.
            if (!Program.RunningInDesigner())
                KryptonRibbon_MarathonForm.Visible = false;
        }

        /// <summary>
        /// Sets up the main ribbon upon loading.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            if (UseRibbon)
                SetupRibbon();

            base.OnLoad(e);
        }

        /// <summary>
        /// Sets up the main ribbon upon activating the document.
        /// </summary>
        protected override void OnActivated(EventArgs e)
        {
            if (UseRibbon)
                SetupRibbon();

            base.OnActivated(e);
        }

        /// <summary>
        /// Set up the main ribbon upon entering the document.
        /// </summary>
        protected override void OnEnter(EventArgs e)
        {
            if (UseRibbon)
                SetupRibbon();

            base.OnEnter(e);
        }

        /// <summary>
        /// Resets the main ribbon upon closing the document.
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (UseRibbon)
                ResetRibbon();

            base.OnClosing(e);
        }

        /// <summary>
        /// Sets up the main ribbon with the properties from the one in this document.
        /// </summary>
        private void SetupRibbon()
        {
            // Check if null first, in case this document doesn't use a ribbon.
            if (UseRibbon)
            {
                // Sets up the main ribbon with this document's controls.
                Workspace.SetupRibbon(InheritanceRibbon,
                                      KryptonRibbon_MarathonForm.RibbonTabs.ToArray(),
                                      KryptonRibbon_MarathonForm.RibbonAppButton.AppButtonMenuItems.ToArray());
            }
            else
            {
                // Reset the main ribbon.
                ResetRibbon();
            }
        }

        /// <summary>
        /// Resets the main ribbon if the controls aren't default.
        /// </summary>
        private void ResetRibbon()
        {
            // No documents are open, so the ribbon should be reset to default.
            if (!Workspace.IsRibbonDefault(InheritanceRibbon))
            {
                // Sets up the main ribbon with default controls.
                Workspace.SetupRibbon(InheritanceRibbon,
                                      Workspace.DefaultRibbonTabs,
                                      null);
            }
        }

        /// <summary>
        /// Docks this document into a dock panel.
        /// </summary>
        public void Show(DockPanel dockPanel, KryptonRibbon ribbon, DockState dockState = DockState.Document)
        {
            // Sets the inheritance ribbon for later.
            InheritanceRibbon = ribbon;

            // Dock the document.
            Show(dockPanel, dockState);
        }

        /// <summary>
        /// Docks this document into a dock panel.
        /// </summary>
        public void ShowDialog(KryptonRibbon ribbon)
        {
            // Sets the inheritance ribbon for later.
            InheritanceRibbon = ribbon;

            // Show the document.
            ShowDialog();
        }
    }
}
