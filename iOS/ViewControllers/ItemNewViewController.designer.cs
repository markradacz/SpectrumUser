﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpectrumApp.iOS
{
    [Register ("ItemNewViewController")]
    partial class ItemNewViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUsername { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSaveItem != null) {
                btnSaveItem.Dispose ();
                btnSaveItem = null;
            }

            if (lblPassword != null) {
                lblPassword.Dispose ();
                lblPassword = null;
            }

            if (lblUsername != null) {
                lblUsername.Dispose ();
                lblUsername = null;
            }

            if (txtDesc != null) {
                txtDesc.Dispose ();
                txtDesc = null;
            }

            if (txtTitle != null) {
                txtTitle.Dispose ();
                txtTitle = null;
            }
        }
    }
}