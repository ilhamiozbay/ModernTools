using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ElasticSearch
{
    public interface IElasticSearchService<T> where T : class
    {
        public void CheckExistsAndInsertLog(T logModel, string indexName);

        public IReadOnlyCollection<AuditLogModel> SearchAuditLog(ElasticAuditLogParameters auditLog, string indexName = "audit_log");
        public IReadOnlyCollection<AuditLogModel> SearchAuditLogByContent(ElasticAuditLogParameters auditLog, string indexName = "audit_log");
    }
}
