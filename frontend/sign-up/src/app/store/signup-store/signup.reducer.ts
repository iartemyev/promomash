import { createReducer, on } from '@ngrx/store';
import { SignUpAction } from './index';
import { initialSignUpState } from './signup.state';

export const machineReducer = createReducer(
	initialSignUpState,
	on(SignUpAction.CountryListLoading, (state) => ({
		...state,
		countryListLoading: true,
		provinceList: [],
	})),

	on(SignUpAction.CountryListSuccess, (state, { payload }) => ({
		...state,
		countryListLoading: false,
		countryList: payload,
	})),

	on(SignUpAction.CountryListFailure, (state) => ({
		...state,
		countryListLoading: false,
	})),

	on(SignUpAction.ProvinceListLoading, (state) => ({
		...state,
		provinceListLoading: true,
	})),

	on(SignUpAction.ProvinceListSuccess, (state, { payload }) => ({
		...state,
		provinceListLoading: false,
		provinceList: payload,
	})),

	on(SignUpAction.ProvinceListFailure, (state) => ({
		...state,
		provinceListLoading: false,
	})),

	on(SignUpAction.SignUpLoading, (state) => ({
		...state,
		signUpLoading: true,
	})),

	on(SignUpAction.SignUpSuccess, (state, { payload }) => ({
		...state,
		signUpLoading: false,
		accessToken: payload,
		login: '',
		password: '',
		isAgree: false,
	})),

	on(SignUpAction.SignUpFailure, (state) => ({
		...state,
		signUpLoading: false,
	})),

	on(SignUpAction.SignUpStepFirstData, (state, { payload }) => ({
		...state,
		login: payload.login,
		password: payload.password,
		isAgree: payload.isAgree,
	})),
);
