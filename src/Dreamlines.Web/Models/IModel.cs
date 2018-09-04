using System;

namespace Dreamlines.Web.Models {

    public interface IModel {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
    }

}
