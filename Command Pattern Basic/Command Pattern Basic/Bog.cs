using System;
using System.Buffers;
using System.Collections.Generic;

public class Bog {
    public List<Side> Sider { get; set; }
    public string Titel { get; set; }
    public string Forfatter { get; set; }

    private IBogSamling Owner;

    public Bog(IBogSamling bib, string titel, string forfatter, params Side[] sider) {
        Titel = titel;
        Forfatter = forfatter;
        Sider = new List<Side>(sider);
        Owner = bib;
    }

    public void OpretSide(int sidetal, string indhold) {
        Side side = new Side(sidetal, indhold);
        Sider.Add(side);
    }

    public void SletSide(int sideNr) {
        if (sideNr < 0 || sideNr >= Sider.Count) {
            throw new ArgumentOutOfRangeException(nameof(sideNr), "Ugyldigt sidenummer");
        }

        Sider.RemoveAt(sideNr);

        if (Sider.Count == 0){
            Owner.SletBog(this);
        }
    }
}
