using System;
using Foundation;
using UIKit;

namespace WebserviceiOS
{
    public partial class CountryTableCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CountryTableCell");
        public static readonly UINib Nib;

        //public UILabel lbl;

        //public CountryTableCell()
        //{
        //    lbl = alpha_code2;

        //}

        static CountryTableCell()
        {
            Nib = UINib.FromName("CountryTableCell", NSBundle.MainBundle);

        }

        protected CountryTableCell(IntPtr handle) : base(handle)
        {
            
        }
    }
}
