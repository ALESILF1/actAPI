
export interface Produto {
  id: string;
  nome: string;
  descricao: string;
  categoria: string;
  preco: number;
  estoque: number;
  dataCriacao: string;
  dataAtualizacao: string;
  IsActive: boolean;
}

export interface CreateProduct {
  nome: string;
  descricao: string;
  preco: number;
  estoque: number;
  categoria: string;
}

export interface UpdateProduct {
  nome: string;
  descricao: string;
  preco: number;
  estoque: number;
  categoria: string;
}
