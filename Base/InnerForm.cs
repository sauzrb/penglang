using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PengLang
{
    public interface InnerForm
    {
        bool IsEdit();
        void Save();
        void HideForm();
        void ShowForm();
    }
}
