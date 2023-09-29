using System.Collections.Generic;

public class Bibliotek : IBogSamling {
    public List<Bog> Boeger { get; set; }

    public Bibliotek() {
        Boeger = new List<Bog>();
    }

    public void OpretBog(string titel, string forfatter, params Side[] sider) {
        Bog bog = new Bog(this, titel, forfatter, sider);
        Boeger.Add(bog);
    }

    public void SletBog(Bog bog) {
        Boeger.Remove(bog);
    }
}
