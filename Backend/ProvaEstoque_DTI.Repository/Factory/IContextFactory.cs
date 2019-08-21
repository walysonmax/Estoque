using ProvaEstoque_DTI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEstoque_DTI.Repository.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}
