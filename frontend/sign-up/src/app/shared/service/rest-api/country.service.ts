import { Injectable } from '@angular/core';
import { RestApiService } from './rest-api.service';
import { Observable } from 'rxjs';
import { ICountryVm } from '../../model/country.vm';

@Injectable({
	providedIn: 'root',
})
export class CountryService {
	public constructor(private restService: RestApiService) {}

	public read(id: string): Observable<ICountryVm> {
		return this.restService.Get<ICountryVm>('Country/Read', {
			id,
		});
	}

	public delete(id: string): Observable<void> {
		return this.restService.Delete('Country/Delete', {
			id,
		});
	}

	public list(): Observable<ICountryVm[]> {
		return this.restService.Get<ICountryVm[]>('Country/List');
	}
}
