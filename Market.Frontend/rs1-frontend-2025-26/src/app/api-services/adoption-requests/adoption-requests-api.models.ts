export interface CreateAdoptionRequestRequest {
  id: number;
  userId: number;
  animalId: number;
  message: string;
  statusId: number;
}

export interface AdoptionRequestDto {
  id: number;
  userId: number;
  animalId: number;
  message: string;
  statusId: number;
  createdAtUtc: string;
  animalName: string;
  animalImageUrl: string | null;
  statusName: string;
  applicantFullName: string;
}
