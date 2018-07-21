namespace SGA.Infra.Dapper.Procedures
{
    public static class AdoptionProcedure
    {
        public const string GetReponsablesAndTheirAdoptions =
            " SELECT(SELECT COUNT(cd_responsavel) FROM adocao where responsavel.cd_responsavel = adocao.cd_responsavel) as AdoptedPets"
                 + " ,cd_responsavel as split"
                 + " ,cd_responsavel as Id"
                 + " ,nm_responsavel as Name"
                 + " ,cpf_responsavel as Number"
                 + " ,email_responsavel as Address"
             + " FROM responsavel";

        public const string FindReponsableAndTheirAdoptionsById =
            "SELECT(SELECT COUNT(cd_responsavel) FROM adocao where responsavel.cd_responsavel = adocao.cd_responsavel) as AdoptedPets"
                + " ,cd_responsavel as split"
                + " ,cd_responsavel as Id"
                + " ,nm_responsavel as Name"
                + " ,cpf_responsavel as Number"
                + " ,email_responsavel as Address"
             + "FROM responsavel"
             + "WHERE  responsavel.cd_responsavel = {0}";
    }
}
