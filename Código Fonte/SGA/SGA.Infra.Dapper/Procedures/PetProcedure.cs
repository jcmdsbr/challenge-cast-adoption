namespace SGA.Infra.Dapper.Procedures
{
    public static class PetProcedure
    {
        public const string GetTypePets =
            "SELECT [cd_tipo_animal] as Id, [dc_tipo_animal] as Description FROM[SGA].[dbo].[tipo_animal]";

        public const string GetPetsNotAdopted =
            " SELECT[cd_animal] as Id, [nm_animal] as Name, [dc_animal] as Description, [animal].[cd_tipo_animal] as TypePetId, " +
            " t.[cd_tipo_animal] as split, t.[cd_tipo_animal] as Id, t.[dc_tipo_animal] as Description " +
            " FROM[SGA].[dbo].[animal] INNER JOIN [dbo].[tipo_animal] as t on  t.cd_tipo_animal = [animal].[cd_tipo_animal] " +
            " WHERE [cd_animal] NOT IN(SELECT cd_animal FROM adocao)";
    }
}