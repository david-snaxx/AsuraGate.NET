using System.Text.Json;
using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;
using SQLite;

namespace AsuraGate.StaticCache.Tests;

public class DyeRepositoryTests
{
    // [Fact]
    // public void Upsert_then_Get_round_trips_to_an_identical_dye()
    // {
    //     // Arrange: a known-good fixture, deserialized the same way a real API response would be.
    //     string json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "dye.json"));
    //     Dye original = JsonSerializer.Deserialize<Dye>(json)
    //         ?? throw new InvalidOperationException("Fixture failed to deserialize.");
    //
    //     using var connection = new SQLiteConnection(":memory:");
    //     connection.CreateTable<DyeEntity>();
    //     connection.CreateTable<DyeCategoryEntity>();
    //
    //     // Act
    //     DyeRepository.Upsert(connection, original);
    //     Dye? roundTripped = DyeRepository.Get(connection, original.Id);
    //
    //     // Assert: compare via re-serialized JSON rather than record equality, since `Dye`'s array properties
    //     // (BaseRgb, Categories, ColorDetail.Rgb) would otherwise compare by reference, not by content.
    //     Assert.NotNull(roundTripped);
    //     string originalJson = JsonSerializer.Serialize(original);
    //     string roundTrippedJson = JsonSerializer.Serialize(roundTripped);
    //     Assert.Equal(originalJson, roundTrippedJson);
    // }
}
