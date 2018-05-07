// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WebserviceiOS
{
    [Register ("CountryTableCell")]
    partial class CountryTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel alpha_code2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel alpha_code3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel namelabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (alpha_code2 != null) {
                alpha_code2.Dispose ();
                alpha_code2 = null;
            }

            if (alpha_code3 != null) {
                alpha_code3.Dispose ();
                alpha_code3 = null;
            }

            if (namelabel != null) {
                namelabel.Dispose ();
                namelabel = null;
            }
        }
    }
}