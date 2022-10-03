namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenreTable_v2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreType) VALUES ('Romance')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Action')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Family')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
