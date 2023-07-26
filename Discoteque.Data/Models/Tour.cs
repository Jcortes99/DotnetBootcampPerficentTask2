using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discoteque.Data.Models;

public  class Tour : BaseEntity<int>
{
    /// <summary>
    /// Name of the Song
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// City name
    /// </summary>
    public string City { get; set; } = "";

    /// <summary>
    /// Is the tour SoldOut?
    /// </summary>
    public bool IsSoldOut { get; set; } = false;
    
    /// <summary>
    /// Tour Date in the city
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// The <see cref="Artist"/> id this Tour belongs to
    /// </summary>
    /// <value></value>
    [ForeignKey("Id")]
    public int ArtistId { get; set; }

    /// <summary>
    /// The <see cref="Artist"/> Entity this album is refering to
    /// </summary> <summary>
    public virtual Artist? Artist { get; set; } 
}