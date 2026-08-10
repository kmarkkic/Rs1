import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AnimalsApiService } from '../../../../api-services/animals/animals-api.service';
import { ListAnimalsQueryDto } from '../../../../api-services/animals/animals-api.models';
import { AdoptionRequestsApiService } from '../../../../api-services/adoption-requests/adoption-requests-api.service';
import { ToasterService } from '../../../../core/services/toaster.service';

@Component({
  selector: 'app-adoption-request-wizard',
  standalone: false,
  templateUrl: './adoption-request-wizard.component.html',
  styleUrl: './adoption-request-wizard.component.scss'
})
export class AdoptionRequestWizardComponent implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private animalsApi = inject(AnimalsApiService);
  private adoptionRequestsApi = inject(AdoptionRequestsApiService);
  private toaster = inject(ToasterService);

  animal = signal<ListAnimalsQueryDto | null>(null);
  isLoadingAnimal = signal(true);
  isSubmitting = signal(false);
  isSubmitted = signal(false);

  personalDataForm!: FormGroup;
  reasonForm!: FormGroup;

  ngOnInit(): void {
    this.buildForms();

    const animalId = Number(this.route.snapshot.paramMap.get('animalId'));
    if (animalId) {
      this.animalsApi.getById(animalId).subscribe({
        next: (a) => {
          this.animal.set(a);
          this.isLoadingAnimal.set(false);
        },
        error: () => {
          this.toaster.error('Životinja nije pronađena');
          this.router.navigate(['/animals']);
        }
      });
    } else {
      this.router.navigate(['/animals']);
    }
  }

  private buildForms(): void {
    this.personalDataForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.pattern(/^[\d\s\+\-\(\)]{7,20}$/)]]
    });

    this.reasonForm = this.fb.group({
      reason: ['', [Validators.required, Validators.minLength(20), Validators.maxLength(1000)]]
    });
  }

  hasPersonalError(control: string, error?: string): boolean {
    const c = this.personalDataForm.get(control);
    if (!c || !c.touched) return false;
    return error ? c.hasError(error) : c.invalid;
  }

  hasReasonError(control: string, error?: string): boolean {
    const c = this.reasonForm.get(control);
    if (!c || !c.touched) return false;
    return error ? c.hasError(error) : c.invalid;
  }

  get reasonLength(): number {
    return this.reasonForm.get('reason')?.value?.length ?? 0;
  }

  onSubmit(): void {
    if (this.isSubmitting() || !this.animal()) return;

    this.reasonForm.markAllAsTouched();
    this.personalDataForm.markAllAsTouched();

    if (this.personalDataForm.invalid || this.reasonForm.invalid) {
      this.toaster.warning('Molimo ispravite greške u formi');
      return;
    }

    this.isSubmitting.set(true);

    const p = this.personalDataForm.value;
    const r = this.reasonForm.value;

    const message = `Ime: ${p.firstName} ${p.lastName}\nEmail: ${p.email}\nTelefon: ${p.phone}\n\nRazlog: ${r.reason}`;

    this.adoptionRequestsApi.create({
      id: 0,
      userId: 1,
      animalId: this.animal()!.id,
      message,
      statusId: 1
    }).subscribe({
      next: () => {
        this.isSubmitting.set(false);
        this.isSubmitted.set(true);
      },
      error: () => {
        this.toaster.error('Greška pri slanju zahtjeva za udomljavanje');
        this.isSubmitting.set(false);
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/animals']);
  }
}
