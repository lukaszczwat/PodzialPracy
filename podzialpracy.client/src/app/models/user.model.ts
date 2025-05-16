export enum UserType {
  Programista = 'Programista',
  Administrator = 'Administrator',
}

export interface User {
  id: number;
  imie: string;
  nazwisko: string;
  typ: UserType;
}
