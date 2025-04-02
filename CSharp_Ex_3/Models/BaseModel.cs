namespace Models {
    public class BaseModel {
        public BaseModel (int id) {
            Id = id;
            CreatedAt = DateTime.Now;
        }

        public int Id {get; set;}
        public DateTime CreatedAt {get; set;}
    }
}