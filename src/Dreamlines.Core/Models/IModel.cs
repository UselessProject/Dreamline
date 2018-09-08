using System;

namespace Dreamlines.Models {

    public interface IModel {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
    }

}
