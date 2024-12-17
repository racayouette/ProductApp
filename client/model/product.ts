export interface Product {
  items: Item[];
  totalItems: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}

export interface Item {
  id: number;
  productName: string;
  price: number;
  imageUrl: string;
  productUrl: string;
}
