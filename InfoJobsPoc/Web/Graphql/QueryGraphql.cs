using InfoJobsPoc.Application.Interfaces.IQuery;
using InfoJobsPoc.Application.Querys;

namespace InfoJobsPoc.Web.Graphql
{
    public class QueryGraphql
    {
        [UseProjection]
        [UseFiltering]
        public IQueryable<CandidateModelQuery> GetCandidate([Service] IQueryApplication<CandidateModelQuery> db) => db.QueryList();
    }
}
