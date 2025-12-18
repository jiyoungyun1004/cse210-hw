using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Personal Crisis Support & Safety Planning System\n");

        // Create user
        Person person = new Person(
            "Sarah Johnson",
            "user001",
            new DateTime(1990, 5, 15)
        );

        Console.WriteLine($"User initialized: {person.Name}");

        // Build safety plan
        SafetyPlan safetyPlan = new SafetyPlan();

        // Warning signs
        safetyPlan.AddWarningSign(new WarningSign(
            "ws001",
            "Feeling hopeless and overwhelmed",
            "High",
            "Emotional"
        ));

        safetyPlan.AddWarningSign(new WarningSign(
            "ws002",
            "Withdrawing from friends and family",
            "Medium",
            "Social"
        ));

        // Coping strategies
        safetyPlan.AddCopingStrategy(new CopingStrategy(
            "cs001",
            "Deep Breathing",
            "Take 10 slow, deep breaths",
            "Physical",
            8
        ));

        safetyPlan.AddCopingStrategy(new CopingStrategy(
            "cs002",
            "Reach Out",
            "Call or text someone you trust",
            "Social",
            9
        ));

        // Reasons for living
        safetyPlan.AddReasonForLiving("My family needs me");
        safetyPlan.AddReasonForLiving("I want to see my children grow up");
        safetyPlan.AddReasonForLiving("My pets depend on me");

        // Support contacts
        safetyPlan.AddSupportContact(new EmergencyContact(
            "ec001",
            "Dr. Lisa Smith",
            "555-1234",
            "Therapist",
            true,
            "15 minutes",
            1
        ));

        safetyPlan.AddSupportContact(new TherapistContact(
            "tc001",
            "County Mental Health Crisis Team",
            "555-5678",
            "Professional",
            true,
            "123 Main St, Suite 200",
            "Crisis Intervention",
            new DateTime(2024, 12, 20)
        ));

        safetyPlan.AddSupportContact(new PeerSupportContact(
            "pc001",
            "Best Friend Mike",
            "555-9999",
            "Close Friend",
            true,
            "Text Message",
            "Evenings and weekends"
        ));

        // Assign plan to user
        person.SetSafetyPlan(safetyPlan);

        // Load crisis resources
        ResourceLibrary resources = new ResourceLibrary();
        resources.LoadDefaultResources();

        // Log symptom entry
        SymptomEntry symptom = new SymptomEntry(
            "se001",
            new DateTime(2024, 12, 15),
            "Feeling anxious and stressed",
            7
        );

        symptom.AddTrigger("Work deadline");
        symptom.AddTrigger("Financial concerns");

        person.AddSymptomEntry(symptom);

        // Assess crisis level
        CrisisLevel crisisLevel = new CrisisLevel(
            "Moderate",
            5,
            "Significant emotional distress",
            "Use coping strategies and contact support"
        );

        safetyPlan.UpdateCrisisLevel(crisisLevel);

        Console.WriteLine("Current Crisis Level:");
        crisisLevel.DisplayCrisisLevel();
        Console.WriteLine();

        // Choose response based on severity
            InterventionProtocol protocol;

if (crisisLevel.SeverityScore >= 8)
{
    protocol = new ImmediateCrisisProtocol(
        "ip001",
        "Immediate Crisis Response",
        crisisLevel,
        "911"
    );
}
else
{
    protocol = new ImmediateCrisisProtocol(
        "ip002",
        "Standard Crisis Response",
        crisisLevel,
        "988"
    );
}

protocol.ExecuteProtocol();
       

        Console.WriteLine("Recommended Action:");
        protocol.ExecuteProtocol();

        // Display full safety plan
        Console.WriteLine("\n--- SAFETY PLAN ---");
        safetyPlan.DisplaySafetyPlan();

        // Display available resources
        Console.WriteLine("\n--- CRISIS RESOURCES ---");
        resources.DisplayAllResources();

        // Display contacts (polymorphic behavior)
        Console.WriteLine("\n--- SUPPORT CONTACTS ---");
        foreach (SupportContact contact in safetyPlan.GetSupportContacts())
        {
            contact.DisplayContact();
            Console.WriteLine();
        }

        Console.WriteLine("Program finished.");
    }
}
