import { Usuario } from './Usuario';

export class Patient {
    id: number;
    sex: string;
    color: string;
    birthdate: Date;
    user: Usuario;
    //armengo tem q fazer um command xD
    name: string;
    email: string;
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