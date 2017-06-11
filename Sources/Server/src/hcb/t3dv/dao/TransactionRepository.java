package hcb.t3dv.dao;

import java.util.List;

import hcb.t3dv.IGenericRepository;
import hcb.t3dv.pojo.Transaction;

public class TransactionRepository implements IGenericRepository<Transaction> {
	
	private static final String DOMAIN = "BackEnd.GiaoDichLogic";
	private static final String ACCOUNT_DOMAIN = "BackEnd.CTGiaoDichLogic";

	@Override
	public List<Transaction> getAll() {
		return null;
	}

	@Override
	public List<Transaction> getList(ISpecification spec) {
		return null;
	}

	@Override
	public Transaction getSingle(ISpecification spec) {
		return null;
	}

	@Override
	public Transaction add(Transaction item) {
		return null;
	}

	@Override
	public Transaction update(Transaction item) {
		return null;
	}

	@Override
	public void remove(Transaction item) {
		
	}

}
