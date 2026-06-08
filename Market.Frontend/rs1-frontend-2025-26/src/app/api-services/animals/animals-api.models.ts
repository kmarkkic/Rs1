import { PageResult } from "../../core/models/paging/page-result";
import { BasePagedQuery } from "../../core/models/paging/base-paged-query";

export class ListAnimalsRequest extends BasePagedQuery {
    animalTypeId?: number | null;
    breedId?: number | null;
    age?: number | null;
    gender?: string | null;
    name?: string | null;
    animalstatusId?: number | null;
}

export interface ListAnimalsQueryDto {
    id: number;
    name: string;
    description: string | null;
    age: number;
    gender: string;
    breedId: number;
    animalTypeId: number;
    shelterId: number;
    ownerId: number | null;
    animalStatusId: number;
    cityId: number;
    isVaccinated: boolean;
    isSterilized: boolean;

    
    breed: BreedDto | null;
    animalType: AnimalTypeDto | null;
    shelter: ShelterDto | null;
    animalStatus: AnimalStatusDto | null;
    images: AnimalImageDto[];
}

export interface BreedDto {
    id: number;
    name: string;
}

export interface AnimalTypeDto {
    id: number;
    name: string;
}

export interface ShelterDto {
    id: number;
    name: string;
}

export interface AnimalStatusDto {
    id: number;
    name: string;
}

export interface AnimalImageDto {
    id: number;
    imageUrl: string;
}

export type ListAnimalsResponse = PageResult<ListAnimalsQueryDto>;