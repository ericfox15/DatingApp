using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedData(AppDbContext context)
    {
        // Guard clause: if users already exist, do nothing
        if (await context.Users.AnyAsync()) return;

        var users = new List<AppUser>
        {
            new() { DisplayName = "Alice", Email = "alice@test.com" },
            new() { DisplayName = "Bob", Email = "bob@test.com" },
            new() { DisplayName = "Carol", Email = "carol@test.com" },
        };

        context.Users.AddRange(users);
        await context.SaveChangesAsync();
    }
}