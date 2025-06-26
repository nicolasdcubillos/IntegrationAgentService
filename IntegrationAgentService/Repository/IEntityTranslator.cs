using IntegrationAgentService.Models.AttachedDocumentSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAgentService.Repository
{
    public interface IEntityTranslator
    {
        Dictionary<string, object> TranslateTrade(AttachedDocument attachedDocument);
    }
}
