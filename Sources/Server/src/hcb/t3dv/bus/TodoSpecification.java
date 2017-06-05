package hcb.t3dv.bus;

import hcb.t3dv.IGenericRepository.ISpecification;

public class TodoSpecification implements ISpecification {
	private final String id;

	private TodoSpecification(String id) {
		this.id = id;
	}
	
	public String id() {
		return id;
	}
	
	public static class Builder {
		
		private String id;
		
		public Builder() {
			
		}
		
		public Builder id(String id) {
			this.id = id;
			return this;
		}
		
		public TodoSpecification build() {
			return new TodoSpecification(this.id);
		}
	}
}
