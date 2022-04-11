import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoggerService } from '../../../shared/service/logger.service';
import { ConfirmedValidator } from '../../../shared/validators/confirm-password.validator';
import { filter } from 'rxjs';
import { StoreFacade } from '../../../shared/facade/store.facade';

@Component({
	selector: 'app-signup-step1',
	templateUrl: './signup-step1.component.html',
	styleUrls: ['./signup-step1.component.scss'],
})
export class SignupStep1Component implements OnInit {
	public form = this._fb.group(
		{
			login: [
				'',
				{
					validators: [Validators.required, Validators.email],
					updateOn: 'blur',
				},
			],
			password: [
				'',
				[Validators.required, Validators.pattern('(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$')],
			],
			confirmPassword: ['', [Validators.required]],
			isAgree: [false, Validators.requiredTrue],
		},
		{
			validator: ConfirmedValidator('password', 'confirmPassword'),
		},
	);

	public constructor(
		private _fb: FormBuilder,
		private _logger: LoggerService,
		private _store: StoreFacade,
	) {}

	public ngOnInit(): void {
		this._logger.info('SignupStep1Component ngOnInit');

		this.form.valueChanges
			.pipe(filter(() => this.form.valid))
			.subscribe((val) => this._store.firstStepData(val));
	}

	public get login() {
		return this.form.controls['login'];
	}

	public get password() {
		return this.form.controls['password'];
	}

	public get confirmPassword() {
		return this.form.controls['confirmPassword'];
	}
}
