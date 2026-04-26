using Microsoft.EntityFrameworkCore;
using SmsService.Models;

namespace SmsService.Data;

public class SmsDbContext : DbContext
{
    public SmsDbContext(DbContextOptions<SmsDbContext> options) : base(options) { }
    public DbSet<SmsMessage> SmsMessages => Set<SmsMessage>();
}
