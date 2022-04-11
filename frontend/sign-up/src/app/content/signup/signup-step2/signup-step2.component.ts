import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoggerService } from '../../../shared/service/logger.service';
import { ICountryVm } from '../../../shared/model/country.vm';
import { Observable } from 'rxjs';
import { IProvinceVm } from '../../../shared/model/province.vm';
import { StoreFacade } from '../../../shared/facade/store.facade';
import { MatSelectChange } from '@angular/material/select';

@Component({
	selector: 'app-signup-step2',
	templateUrl: './signup-step2.component.html',
	styleUrls: ['./signup-step2.component.scss'],
})
export class SignupStep2Component implements OnInit {
	public form = this._fb.group({
		country: ['', Validators.required],
		province: ['', Validators.required],
	});

	public countryList$: Observable<ICountryVm[]> = this._store.selectCountryList();

	public countryListLoading$: Observable<boolean> = this._store.selectCountryListLoading();

	public provinceList$: Observable<IProvinceVm[]> = this._store.selectProvinceList();

	public provinceListLoading$: Observable<boolean> = this._store.selectProvinceListLoading();

	public constructor(
		private _fb: FormBuilder,
		private _logger: LoggerService,
		private _store: StoreFacade,
	) {}

	public ngOnInit(): void {
		this._logger.info('SignupStep2Component ngOnInit');

		this._store.countryListLoading();
	}

	public onCountryChange($event: MatSelectChange) {
		this._logger.info(`onCountryChange: ${$event.value}`);

		this._store.provinceListLoading($event.value);
	}
}
