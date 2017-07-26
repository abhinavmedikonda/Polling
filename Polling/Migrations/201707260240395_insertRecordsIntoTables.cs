namespace Polling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertRecordsIntoTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Polls(Name) VALUES('Car')");
            Sql("INSERT INTO Polls(Name) VALUES('Bike')");
            Sql("INSERT INTO Polls(Name) VALUES('Gun')");
            Sql("INSERT INTO Polls(Name) VALUES('Ice')");

            Sql("INSERT INTO Items(PollId, Name) VALUES(1, 'Rogue')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(1, 'Civic')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(1, 'I10')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(1, 'Mustang')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(2, 'Pulsar')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(2, 'Splendor')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(2, 'RXZ')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(2, 'Apche')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(3, 'Insas')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(3, 'AK47')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(4, 'Vanilla')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(4, 'Chocolate')");
            Sql("INSERT INTO Items(PollId, Name) VALUES(4, 'Mango')");

            Sql("INSERT INTO Votes(AspNetUserId, ItemId) VALUES('84a8f385-adb6-42d7-97c3-b72fb035c64e', 2)");
            Sql("INSERT INTO Votes(AspNetUserId, ItemId) VALUES('84a8f385-adb6-42d7-97c3-b72fb035c64e', 5)");
            Sql("INSERT INTO Votes(AspNetUserId, ItemId) VALUES('84a8f385-adb6-42d7-97c3-b72fb035c64e', 10)");
            Sql("INSERT INTO Votes(AspNetUserId, ItemId) VALUES('84a8f385-adb6-42d7-97c3-b72fb035c64e', 12)");
        }
        
        public override void Down()
        {
        }
    }
}
