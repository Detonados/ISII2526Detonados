using System;
public class Model
{
    //Atributos 
    private int id;
    private string nameModel;
    private IList<Device> devices;

   / Getters y Setters
    public int GetId(){
        return this.id;
    }

    public void SetId(int id){
        this.id = id;
    }

    public string GetNameModel(){
        return this.nameModel;
    }

    public void SetNameModel(string nameModel){
        this.nameModel = nameModel;
    }

    // Constructores 
    public Model()
    {
        this.devices = new List<Device>();
    }

    public Model(int id, string nameModel){
        // Llamada explícita al constructor sin parámetros
        this(); // Así como lo harías en Java
        this.id = id;
        this.nameModel = nameModel;
    }
    public int GetId(){
    return this.id;
    }


public override bool Equals(object obj){
    return obj is Model m && this.id == m.id;
}

public override int GetHashCode()
{
    return this.id.GetHashCode();
}
}