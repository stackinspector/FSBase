namespace Berylsoft.Base

// TODO finish document
/// <summary>Note that all Berylsoft software must use <see cref="T:System.DateTimeOffset" /> as the standard internal representation of time and use the "standard timestamp" as the standard exchangeable and persistent representation of time. If needed, convert the above representation to <see cref="T:System.DateTime" /> at the interaction boundary.</summary>
module Time =

    open System

    let inline fromDateTime (dateTime: DateTime) : DateTimeOffset =
        DateTimeOffset dateTime

    let inline toDateTime (time: DateTimeOffset) : DateTime =
        time.LocalDateTime
    
    let inline fromTimestamp (timestamp: int64) : DateTimeOffset =
        DateTimeOffset.FromUnixTimeMilliseconds timestamp

    let inline toTimestamp (time: DateTimeOffset) : int64 =
        time.ToUnixTimeMilliseconds ()

    let fromTicks (ticks: int64) : DateTimeOffset =
        (ticks, TimeSpan.Zero)
        |> DateTimeOffset

    let inline toTicks (time: DateTimeOffset) : int64 =
        time.UtcTicks

    let inline accToStd (acc: int64) : int64 =
        acc / TimeSpan.TicksPerMillisecond

    let inline stdToAcc (std: int64) : int64 =
        std * TimeSpan.TicksPerMillisecond

    // TODO optimization
    let accToStdRounded (acc: int64) : int64 =
        acc
        |> float
        |> fun accTimestamp -> accTimestamp / float TimeSpan.TicksPerMillisecond
        |> Math.Round
        |> int64

    let fromAccTimestamp (timestamp: int64) : DateTimeOffset =
        timestamp
        |> fun ticks -> ticks + DateTimeOffset.UnixEpoch.UtcTicks
        |> fromTicks

    let toAccTimestamp (time: DateTimeOffset) : int64 =
        time
        |> toTicks
        |> fun ticks -> ticks - DateTimeOffset.UnixEpoch.UtcTicks

    let toTimestampRounded (time: DateTimeOffset) : int64 =
        time
        |> toAccTimestamp
        |> accToStdRounded
