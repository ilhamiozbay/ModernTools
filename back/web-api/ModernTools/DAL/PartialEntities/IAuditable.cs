using System;

namespace DAL.PartialEntities
{
    //İlgili interfaceden türemiş sınıflar Güncellendiği ya da Silindiği zaman Audit kaydı ElasticSearch'ün "audit_log" indexine kaydedilir.
    public interface IAuditable
    {
    }
}
