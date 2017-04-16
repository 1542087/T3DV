package hcb.t3dv.pojo;

public class Todo {
	private String id;
    private String summary;
    private String description;
    
    public Todo() {
    	
    }
    
	public Todo(String id, String summary, String description) {
		this.id = id;
		this.summary = summary;
		this.description = description;
	}

	public String getId() {
		return id;
	}

	public String getSummary() {
		return summary;
	}

	public String getDescription() {
		return description;
	}
}
