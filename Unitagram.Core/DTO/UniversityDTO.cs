﻿using Unitagram.Core.Domain.Entities;

namespace Unitagram.Core.DTO
{
    /// <summary>
    /// DTO class that is used for map entity to DTO
    /// </summary>
    public class UniversityDTO
    {
        public int? UniversityID { get; set; }
        public string? Province { get; set; }
        public string? UniversityName { get; set; }
        public List<UniversityDomainDTO> Domains { get; set; } = new List<UniversityDomainDTO>();

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(UniversityDTO))
            {
                return false;
            }
            UniversityDTO university_to_compare = (UniversityDTO)obj;

            return UniversityID == university_to_compare.UniversityID
                && Province == university_to_compare.Province
                && UniversityName == university_to_compare.UniversityName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; // Choose a prime number as the initial hash code

                // Combine hash codes of properties using prime numbers
                hash = hash * 23 + (UniversityID?.GetHashCode() ?? 0);
                hash = hash * 23 + (Province?.GetHashCode() ?? 0);
                hash = hash * 23 + (UniversityName?.GetHashCode() ?? 0);
                hash = hash * 23 + (Domains?.GetHashCode() ?? 0);

                return hash;
            }
        }
    }

    public static class UniversityDTOExtensions
    {
        public static UniversityDTO ToUniversityDTO(this University university)
        {
            return new UniversityDTO()
            {
                UniversityID = university.UniversityId,
                Province = university.Province,
                UniversityName = university.Name,
                Domains = university.UniversityDomains
                        .Select(t => t.ToUniversityDomainDTO())
                        .ToList(),
            };
        }
    }


}
