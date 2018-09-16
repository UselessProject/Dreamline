using Dreamlines.Models;

namespace Dreamlines.Tests.Integrations {
    
    public interface IDreamlinesDbInitializer {
        void Initialize(DreamlinesContext db);
    }
    
}