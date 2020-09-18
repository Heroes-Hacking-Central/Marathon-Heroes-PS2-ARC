﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marathon.Toolkit.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Marathon.Toolkit.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Marathon&gt;
        ///  &lt;!-- If no URL or description is specified, only your name will be displayed. --&gt;
        ///  &lt;Contributor URL=&quot;https://github.com/HyperPolygon64&quot; Description=&quot;Lead developer and designer of Marathon&quot;&gt;HyperPolygon64&lt;/Contributor&gt;
        ///  &lt;Contributor URL=&quot;https://github.com/Radfordhound&quot; Description=&quot;Developed the HedgeLib# classes used as a base for Marathon.IO&quot;&gt;Radfordhound&lt;/Contributor&gt;
        ///  &lt;Contributor URL=&quot;https://github.com/Knuxfan24&quot; Description=&quot;Assisted with  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Contributors {
            get {
                return ResourceManager.GetString("Contributors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is likely caused by a property in the configuration file that doesn&apos;t exist or it&apos;s being deserialised to an incorrect data type..
        /// </summary>
        internal static string Exception_InvalidSettingsException {
            get {
                return ResourceManager.GetString("Exception_InvalidSettingsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Feedback_Error {
            get {
                object obj = ResourceManager.GetObject("Feedback_Error", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Feedback_Information {
            get {
                object obj = ResourceManager.GetObject("Feedback_Information", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Feedback_Question {
            get {
                object obj = ResourceManager.GetObject("Feedback_Question", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Feedback_Warning {
            get {
                object obj = ResourceManager.GetObject("Feedback_Warning", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap FileConverter_FileDrop {
            get {
                object obj = ResourceManager.GetObject("FileConverter_FileDrop", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Marathon&gt;
        ///  &lt;!-- If no extension is specified or is a duplicate, the entry will be disregarded. --&gt;
        ///  &lt;Type Extension=&quot;.*&quot;&gt;All files&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.pkg&quot;&gt;Asset Package&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.bin&quot;&gt;Collision&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.arc&quot;&gt;Compressed U8 Archive&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.dds&quot;&gt;DirectDraw Surface&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.path&quot;&gt;Path Spline&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.pft&quot;&gt;Picture Font&lt;/Type&gt;
        ///  &lt;Type Extension=&quot;.set&quot;&gt;Placement&lt;/Ty [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FileTypes {
            get {
                return ResourceManager.GetString("FileTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Format_File {
            get {
                object obj = ResourceManager.GetObject("Format_File", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Format_Folder {
            get {
                object obj = ResourceManager.GetObject("Format_Folder", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon Icon {
            get {
                object obj = ResourceManager.GetObject("Icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sonic the Hedgehog and binary formats respective to SONIC THE HEDGEHOG (2006) are property of SEGA Corporation.
        ///
        ///Marathon and its contributors are not affiliated with SEGA Corporation and/or SEGA CS R&amp;D No. 2..
        /// </summary>
        internal static string Information_License {
            get {
                return ResourceManager.GetString("Information_License", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Logo_Corner_Transparent {
            get {
                object obj = ResourceManager.GetObject("Logo_Corner_Transparent", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Logo_Full_Colour {
            get {
                object obj = ResourceManager.GetObject("Logo_Full_Colour", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Logo_Medium_Colour {
            get {
                object obj = ResourceManager.GetObject("Logo_Medium_Colour", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Logo_Small_Dark {
            get {
                object obj = ResourceManager.GetObject("Logo_Small_Dark", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_Back_Disabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_Back_Disabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_Back_Enabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_Back_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_Clipboard_Enabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_Clipboard_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_DirectoryTree_Enabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_DirectoryTree_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_Forward_Disabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_Forward_Disabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_Forward_Enabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_Forward_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MarathonExplorer_Up_Enabled {
            get {
                object obj = ResourceManager.GetObject("MarathonExplorer_Up_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Placeholder {
            get {
                object obj = ResourceManager.GetObject("Placeholder", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Marathon&gt;
        ///  &lt;!-- Vertex and Fragment shaders are inherited by name from .NET resources. --&gt;
        ///  &lt;Shader Vertex=&quot;SimpleVertex&quot; Fragment=&quot;SimpleFragment&quot;&gt;Simple&lt;/Shader&gt;
        ///&lt;/Marathon&gt;
        ///.
        /// </summary>
        internal static string Shaders {
            get {
                return ResourceManager.GetString("Shaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Archive {
            get {
                object obj = ResourceManager.GetObject("Task_Archive", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Bug {
            get {
                object obj = ResourceManager.GetObject("Task_Bug", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Exit {
            get {
                object obj = ResourceManager.GetObject("Task_Exit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Export {
            get {
                object obj = ResourceManager.GetObject("Task_Export", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Information {
            get {
                object obj = ResourceManager.GetObject("Task_Information", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_New {
            get {
                object obj = ResourceManager.GetObject("Task_New", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_NewFile {
            get {
                object obj = ResourceManager.GetObject("Task_NewFile", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_NewFileCollection {
            get {
                object obj = ResourceManager.GetObject("Task_NewFileCollection", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_NewFolder {
            get {
                object obj = ResourceManager.GetObject("Task_NewFolder", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Open {
            get {
                object obj = ResourceManager.GetObject("Task_Open", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_OpenDialog {
            get {
                object obj = ResourceManager.GetObject("Task_OpenDialog", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_OpenFile {
            get {
                object obj = ResourceManager.GetObject("Task_OpenFile", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_OpenFolder {
            get {
                object obj = ResourceManager.GetObject("Task_OpenFolder", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Output {
            get {
                object obj = ResourceManager.GetObject("Task_Output", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Task_Settings {
            get {
                object obj = ResourceManager.GetObject("Task_Settings", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://github.com/HyperPolygon64/Marathon/issues/new.
        /// </summary>
        internal static string URL_GitHubIssueNew {
            get {
                return ResourceManager.GetString("URL_GitHubIssueNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap UserControlForm_Close_Enabled {
            get {
                object obj = ResourceManager.GetObject("UserControlForm_Close_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap UserControlForm_Maximise_Enabled {
            get {
                object obj = ResourceManager.GetObject("UserControlForm_Maximise_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap UserControlForm_Minimise_Enabled {
            get {
                object obj = ResourceManager.GetObject("UserControlForm_Minimise_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap UserControlForm_Restore_Enabled {
            get {
                object obj = ResourceManager.GetObject("UserControlForm_Restore_Enabled", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
