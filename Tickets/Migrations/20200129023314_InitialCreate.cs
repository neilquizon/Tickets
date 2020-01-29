using Microsoft.EntityFrameworkCore.Migrations;

namespace Tickets.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketPurchase",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    PaymentAmount = table.Column<decimal>(nullable: false),
                    ConfirmationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchase", x => x.PurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueName = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.VenueName);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(nullable: true),
                    VenueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Venue_VenueName",
                        column: x => x.VenueName,
                        principalTable: "Venue",
                        principalColumn: "VenueName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionName = table.Column<string>(nullable: true),
                    VenueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Section_Venue_VenueName",
                        column: x => x.VenueName,
                        principalTable: "Venue",
                        principalColumn: "VenueName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    RowId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RowName = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_Row_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(nullable: true),
                    RowId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_Row_RowId",
                        column: x => x.RowId,
                        principalTable: "Row",
                        principalColumn: "RowId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventSeat",
                columns: table => new
                {
                    EventSeatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeatId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    EventSeatPrice = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSeat", x => x.EventSeatId);
                    table.ForeignKey(
                        name: "FK_EventSeat_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSeat_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchaseSeat",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventSeatId = table.Column<int>(nullable: false),
                    SeatSubtotal = table.Column<decimal>(nullable: true),
                    PurchaseId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchaseSeat", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseSeat_EventSeat_EventSeatId",
                        column: x => x.EventSeatId,
                        principalTable: "EventSeat",
                        principalColumn: "EventSeatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseSeat_TicketPurchase_PurchaseId1",
                        column: x => x.PurchaseId1,
                        principalTable: "TicketPurchase",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_VenueName",
                table: "Event",
                column: "VenueName");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeat_EventId",
                table: "EventSeat",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeat_SeatId",
                table: "EventSeat",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_SectionId",
                table: "Row",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_RowId",
                table: "Seat",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_VenueName",
                table: "Section",
                column: "VenueName");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseSeat_EventSeatId",
                table: "TicketPurchaseSeat",
                column: "EventSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseSeat_PurchaseId1",
                table: "TicketPurchaseSeat",
                column: "PurchaseId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketPurchaseSeat");

            migrationBuilder.DropTable(
                name: "EventSeat");

            migrationBuilder.DropTable(
                name: "TicketPurchase");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}
