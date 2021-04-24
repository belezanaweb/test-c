using System.Collections.Generic;

namespace Boticario.Api.ViewModels
{
    public class ResponseViewModel
    {
        #region Constructors

        public ResponseViewModel()
        {
            errors = new List<string>();
        }

        #endregion

        #region Attributes

        public bool success { get; set; }

        public object data { get; set; }

        public IList<string> errors { get; set; }

        #endregion
    }
}