using System;
using System.Collections.Generic;
using System.Linq;

public class ResourceLibrary
{
    private readonly List<CrisisResource> _resources;

    public ResourceLibrary()
    {
        _resources = new List<CrisisResource>();
    }

    public void AddResource(CrisisResource resource)
    {
        if (resource == null)
        {
            return;
        }

        _resources.Add(resource);
    }

    public IReadOnlyList<CrisisResource> GetAllResources()
    {
        return _resources;
    }

    public IReadOnlyList<CrisisResource> GetResourcesByType(string type)
    {
        return _resources
            .Where(r => r.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<CrisisResource> GetEmergencyResources()
    {
        return _resources
            .Where(r => r.IsAvailableNow())
            .ToList();
    }

    public IReadOnlyList<CrisisResource> SearchResources(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return new List<CrisisResource>();
        }

        keyword = keyword.ToLower();

        return _resources
            .Where(r =>
                r.Name.ToLower().Contains(keyword) ||
                r.Description.ToLower().Contains(keyword))
            .ToList();
    }

    public void DisplayAllResources()
    {
        Console.WriteLine($"Total Resources Available: {_resources.Count}\n");

        foreach (var resource in _resources)
        {
            resource.DisplayResource();
            Console.WriteLine();
        }
    }

    public void LoadDefaultResources()
    {
        AddResource(new CrisisResource(
            "r001",
            "National Suicide Prevention Lifeline",
            "Hotline",
            "988",
            "24/7 crisis support and suicide prevention",
            "24/7"
        ));

        AddResource(new CrisisResource(
            "r002",
            "Crisis Text Line",
            "Text Support",
            "Text HOME to 741741",
            "Free 24/7 text-based crisis support",
            "24/7"
        ));

        AddResource(new CrisisResource(
            "r003",
            "SAMHSA National Helpline",
            "Hotline",
            "1-800-662-4357",
            "Mental health and substance abuse treatment referral",
            "24/7"
        ));

        AddResource(new CrisisResource(
            "r004",
            "Veterans Crisis Line",
            "Hotline",
            "988 then press 1",
            "Crisis support for veterans and their families",
            "24/7"
        ));
    }
}
