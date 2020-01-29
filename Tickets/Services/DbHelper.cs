using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Services
{
      
        public partial class Event
        {
            public Event()
            {
                EventSeat = new HashSet<EventSeat>();
            }
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int EventId { get; set; }
            public string EventName { get; set; }
            public string VenueName { get; set; }

            public virtual Venue VenueNameNavigation { get; set; }
            public virtual ICollection<EventSeat> EventSeat { get; set; }
        }

        public partial class EventSeat
        {
            public EventSeat()
            {
                TicketPurchaseSeat = new HashSet<TicketPurchaseSeat>();
            }

            public int EventSeatId { get; set; }
            public int SeatId { get; set; }
            public int EventId { get; set; }
            public decimal? EventSeatPrice { get; set; }

            public virtual Event Event { get; set; }
            public virtual Seat Seat { get; set; }
            public virtual ICollection<TicketPurchaseSeat> TicketPurchaseSeat { get; set; }
        }

        public partial class Row
        {
            public Row()
            {
                Seat = new HashSet<Seat>();
            }

            public int RowId { get; set; }
            public string RowName { get; set; }
            public int? SectionId { get; set; }

            public virtual Section Section { get; set; }
            public virtual ICollection<Seat> Seat { get; set; }
        }

        public partial class Seat
        {
            public Seat()
            {
                EventSeat = new HashSet<EventSeat>();
            }

            public int SeatId { get; set; }
            public decimal? Price { get; set; }
            public int? RowId { get; set; }

            public virtual Row Row { get; set; }
            public virtual ICollection<EventSeat> EventSeat { get; set; }
        }

        public partial class Section
        {
            public Section()
            {
                Row = new HashSet<Row>();
            }

            public int SectionId { get; set; }
            public string SectionName { get; set; }
            public string VenueName { get; set; }

            public virtual Venue VenueNameNavigation { get; set; }
            public virtual ICollection<Row> Row { get; set; }
        }

        public partial class TicketPurchase
        {
            public TicketPurchase()
            {
                TicketPurchaseSeat = new HashSet<TicketPurchaseSeat>();
            }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PurchaseId { get; set; }
            public string PaymentMethod { get; set; }
            public decimal PaymentAmount { get; set; }
            public string ConfirmationCode { get; set; }

            public virtual ICollection<TicketPurchaseSeat> TicketPurchaseSeat { get; set; }
        }

        public partial class TicketPurchaseSeat
        {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }
            public int EventSeatId { get; set; }
            public decimal? SeatSubtotal { get; set; }

            public virtual EventSeat EventSeat { get; set; }
            public virtual TicketPurchase Purchase { get; set; }
        }

        public partial class Venue
        {
            public Venue()
            {
                Event = new HashSet<Event>();
                Section = new HashSet<Section>();
            }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string VenueName { get; set; }
            public int? Capacity { get; set; }

            public virtual ICollection<Event> Event { get; set; }
            public virtual ICollection<Section> Section { get; set; }
        }
                           

        public partial class TicketsDbContext : DbContext
        {
           public TicketsDbContext(DbContextOptions<TicketsDbContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Event> Event { get; set; }
            public virtual DbSet<EventSeat> EventSeat { get; set; }
            public virtual DbSet<Row> Row { get; set; }
            public virtual DbSet<Seat> Seat { get; set; }
            public virtual DbSet<Section> Section { get; set; }
            public virtual DbSet<TicketPurchase> TicketPurchase { get; set; }
            public virtual DbSet<TicketPurchaseSeat> TicketPurchaseSeat { get; set; }
            public virtual DbSet<Venue> Venue { get; set; }

        }
       
}
