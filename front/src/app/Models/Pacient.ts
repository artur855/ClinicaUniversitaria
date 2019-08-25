import { Usuario } from './Usuario';

export class Patient {
    id: number;
    usuario: Usuario;
    sex: String;
    color: String;
    birthdate: String;
}

export enum PatientColor {
    Branco = 0,
    Negro = 1,
    Pardo = 2,
    Indigena = 3,
    'Nao Especificado' = 4
}

export enum PatientSex {
    Masculino = 'M',
    Feminino = 'F'
}