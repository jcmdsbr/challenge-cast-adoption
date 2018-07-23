namespace SGA.Infra.Dapper.Procedures
{
    public static class AdoptionProcedure
    {
        public const string GetReponsablesAndTheirAdoptions =
            " SELECT(SELECT COUNT(cd_responsavel) FROM adocao WHERE responsavel.cd_responsavel = adocao.cd_responsavel) as AdoptedPets"
            + " ,cd_responsavel as split"
            + " ,cd_responsavel as Id"
            + " ,nm_responsavel as Name"
            + " ,0 as splitCpf"
            + " ,cpf_responsavel as Number"
            + " ,0 as splitEmail"
            + " ,email_responsavel as Address"
            + " FROM responsavel ";

        public const string FindReponsableAndTheirAdoptionsById =
            " SELECT(SELECT COUNT(cd_responsavel) FROM adocao WHERE responsavel.cd_responsavel = adocao.cd_responsavel) as AdoptedPets"
            + " ,cd_responsavel as split"
            + " ,cd_responsavel as Id"
            + " ,nm_responsavel as Name"
            + " ,0 as splitCpf"
            + " ,cpf_responsavel as Number"
            + " ,0 as splitEmail"
            + " ,email_responsavel as Address"
            + " FROM responsavel "
            + " WHERE  responsavel.cd_responsavel = '{0}' ";
    }
}