using RUIANDownloader.Models;

namespace RUIANDownloader.Interfaces.Models
{

    public interface IAddress
    {

        /// <summary>
        /// Kód ADM - Kód adresního místa vedeného v Informačním systému územní identifikace (ISÚI).
        /// </summary>
        int Id { get; set; }


        /// <summary>
        /// Kód obce - Kód obce vedené v ISÚI, ze které jsou vypsána všechna adresní místa.
        /// </summary>
        int MunicipalityId { get; set; }


        /// <summary>
        /// Název obce - Název obce, ze které jsou vypsána všechna adresní místa.
        /// </summary>
        string Name { get; set; }


        /// <summary>
        /// Kód MOMC - Kód městského obvodu/městské části, který je vyplněn pouze v případě členěných statutárních měst.
        /// </summary>
        int? MunicipalityDistrictId { get; set; }


        /// <summary>
        /// Název MOMC - Název městského obvodu/městské části, který je vyplněn pouze v případě členěných statutárních měst.
        /// </summary>
        string? MunicipalityDistrictName { get; set; }


        /// <summary>
        /// Kód obvodu - Prahy Kód obvodu Prahy, který je vyplněn pouze v případě Hlavního města Prahy.
        /// </summary>
        int? MunicipalityPrgDistrictId { get; set; }


        /// <summary>
        /// Název obvodu - Prahy Název obvodu Prahy, který je vyplněn pouze v případě Hlavního města Prahy.
        /// </summary>
        string? MunicipalityPrgDistrictName { get; set; }


        /// <summary>
        /// Kód části obce - Kód části obce v rámci nadřazené obce, ve které je číslován stavební objekt.
        /// </summary>
        int? MunicipalityPartId { get; set; }


        /// <summary>
        /// Název části obce - Název části obce v rámci nadřazené obce, ve které je číslován stavební objekt.
        /// </summary>
        string? MunicipalityPartName { get; set; }


        /// <summary>
        /// Kód ulice - Kód ulice, která je navázána na adresní místo. Může být vyplněn pouze u obcí, které mají zavedenu uliční síť.
        /// </summary>
        int? StreetId { get; set; }


        /// <summary>
        /// Název ulice - Název ulice, která je navázána na adresní místo. Může být vyplněn pouze u obcí, které mají zavedenu uliční síť.
        /// </summary>
        string? StreetName { get; set; }


        /// <summary>
        /// Typ SO - Typ stavebního objektu (č.ev., č.p.)
        /// </summary>
        TypeOfBuilding TypeOfBuilding { get; set; }


        /// <summary>
        /// Číslo domovní - Číslo popisné nebo číslo evidenční, podle rozlišeného typu SO.
        /// </summary>
        int BuildingNumber { get; set; }


        /// <summary>
        /// Číslo orientační - Číslo orientační, slouží k orientaci v rámci nadřazené ulice.
        /// </summary>
        int? OrientationNumber { get; set; }


        /// <summary>
        /// Znak čísla orientačního - Znak čísla orientačního, uveden v případě, že je znak k orientačnímu číslu přidělen.
        /// </summary>
        string? OrientationNumberChar { get; set; }


        /// <summary>
        /// PSČ - Poštovní směrovací číslo.
        /// </summary>
        int PostCode { get; set; }


        /// <summary>
        /// Souřadnice Y - Souřadnice Y definičního bodu adresního místa v systému S-JTSK (systém jednotné trigonometrické sítě katastrální), uvedené v[m].
        /// </summary>
        double CoordinateY { get; set; }


        /// <summary>
        /// Souřadnice X - Souřadnice X definičního bodu adresního místa v systému S-JTSK(systém jednotné trigonometrické sítě katastrální), uvedené v[m].
        /// </summary>
        double CoordinateX { get; set; }


        /// <summary>
        /// Platí Od - Datum platnosti adresního místa.
        /// </summary>
        DateTime ValidFrom { get; set; }

    }

}
