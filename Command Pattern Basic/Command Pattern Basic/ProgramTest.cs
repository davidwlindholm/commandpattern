using Xunit;
public class ProgramTest {
    private Bibliotek OpretBibliotek() {
        Bibliotek bibliotek = new Bibliotek();
        bibliotek.OpretBog("The Lord of the Rings", "J.R.R. Tolkien", new Side(0, "The Fellowship of the Ring"));
        bibliotek.OpretBog("The Lord of the Rings 2", "J.R.R. Tolkien", new Side(0, "The Two Towers"));
        bibliotek.OpretBog("The Lord of the Rings 3", "J.R.R. Tolkien", new Side(0, "The Return of the King"));
        return bibliotek;
    } 

    [Fact]
    public void Boeger_kan_tilfoejes_til_bibliotek() {
        Bibliotek bibliotek = OpretBibliotek();
        Assert.Equal(3, bibliotek.Boeger.Count);
    }

    [Fact]
    public void Boeger_kan_slettes_fra_bibliotek() {
        Bibliotek bibliotek = OpretBibliotek();
        Bog bog = bibliotek.Boeger[0];
        bibliotek.SletBog(bog);
        Assert.DoesNotContain(bog, bibliotek.Boeger);
    }

    [Fact]
    public void Sider_kan_tilfoejes_til_bog() {
        Bibliotek bibliotek = OpretBibliotek();
        Bog bog = bibliotek.Boeger[0];
        bog.OpretSide(2, "The Shadow of the Past");
        Assert.Equal(2, bog.Sider.Count);
    }

    [Fact]
    public void Sider_kan_slettes_fra_bog() {
        Bibliotek bibliotek = OpretBibliotek();
        Bog bog = bibliotek.Boeger[0];
        bog.SletSide(0);
        Assert.Empty(bog.Sider);
    }

    [Fact]
    public void Ugyldig_side_kan_ikke_slettes_fra_bog() {
        Bibliotek bibliotek = OpretBibliotek();
        Bog bog = bibliotek.Boeger[0];
        Assert.Throws<System.ArgumentOutOfRangeException>(() => bog.SletSide(-1));
        Assert.Throws<System.ArgumentOutOfRangeException>(() => bog.SletSide(1));
    }

    [Fact]
    public void Sider_kan_slettes_fra_bog_og_bog_slettes_hvis_den_er_tom() {
        Bibliotek bibliotek = OpretBibliotek();
        Bog bog = bibliotek.Boeger[0];
        bog.SletSide(0);
        Assert.Equal(2, bibliotek.Boeger.Count);
    }



}