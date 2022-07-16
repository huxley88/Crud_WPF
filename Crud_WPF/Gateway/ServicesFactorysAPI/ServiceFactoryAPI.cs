using System;

namespace Crud_WPF.Gateway.ServicesFactorysAPI
{
    public abstract class ServiceFactoryAPI
    {
        public ServiceFactoryAPI()
        {
            RenomearController();
        }

        protected string _NomeControllerAPI { get; set; }

        protected string _RotaPadrao
        {
            get
            {
                string path = "/api/";

                return path;
            }
        }

        public abstract void RenomearController();

        public virtual string RotaAPI()
        {
            if (string.IsNullOrEmpty(_NomeControllerAPI))
                throw new ArgumentNullException("Nome do controller da API não informado.");

            return $"{_RotaPadrao}{_NomeControllerAPI}";
        }
    }
}
