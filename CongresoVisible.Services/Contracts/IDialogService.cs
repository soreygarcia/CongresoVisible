using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Services.Contracts
{
    public interface IDialogService
    {
        void ShowMessage(string message, string title, string buttonText);
        void ShowError(string errorMessage, string title, string buttonText);
        void ShowError(Exception error, string title, string buttonText);
    }
}
