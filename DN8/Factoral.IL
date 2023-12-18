.assembly Factorial {}
.assembly extern mscorlib {}

.method public static void Main() cil managed
{
    .entrypoint
        .locals init (
            [0] int32 n,
    [1] int32 k
        )
    ldc.i4.5 
    stloc.0 
    ldc.i4.1 
    stloc.1 

    br.s CheckLoop 

    LoopStart: 
    ldloc.1 
    ldloc.0 
    mul 
        stloc.1 // speichere das Ergebnis in k
    ldloc.0 // lade den Wert von n auf den Stack
    ldc.i4.1 // lade die Zahl 1 auf den Stack
    sub // subtrahiere 1 von n
        stloc.0 // speichere das Ergebnis in n

    CheckLoop: // Label für die Überprüfung der Schleife
    ldloc.0 // lade den Wert von n auf den Stack
    ldc.i4.1 // lade die Zahl 1 auf den Stack
    bgt.s LoopStart // wenn n > 1, gehe zurück zum Schleifenanfang

    // Printe die Ergebnisse
    ldloc.1 // lade den Wert von k auf den Stack
    call void [mscorlib]System.Console::WriteLine(int32) // rufe die WriteLine Methode auf

    // Beende das Programm
    ret
}